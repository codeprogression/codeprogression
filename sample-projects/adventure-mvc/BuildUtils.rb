require 'rubygems'
require 'erb'           
require 'fileutils'
require 'activesupport'
require 'find'
require 'zip/zip'
require 'zip/zipfilesystem'

class NUnitRunner
	include FileTest

	def initialize(paths)
		@sourceDir = paths.fetch(:source, 'source')
		@resultsDir = paths.fetch(:results, 'results')
		@compilePlatform = paths.fetch(:platform, '')
		@compileTarget = paths.fetch(:compilemode, 'debug')
        @coverageAssemblies = paths.fetch(:coverageAssemblies, '')
        @projectName = paths.fetch(:projectName, '')
        @minimumCoverage = paths.fetch(:minimumCoverage, '70')
        if ENV["teamcity.dotnet.nunitlauncher"] # check if we are running in TeamCity
                    # We are not using the TeamCity nunit launcher. We use NUnit with the TeamCity NUnit Addin which needs tO be copied to our NUnit addins folder
                    # http://blogs.jetbrains.com/teamcity/2008/07/28/unfolding-teamcity-addin-for-nunit-secrets/
                    # The teamcity.dotnet.nunitaddin environment variable is not available until TeamCity 4.0, so we hardcode it for now
                    @teamCityAddinPath = ENV["teamcity.dotnet.nunitaddin"] ? ENV["teamcity.dotnet.nunitaddin"] : 'c:/TeamCity/buildAgent/plugins/dotnetPlugin/bin/JetBrains.TeamCity.NUnitAddin-NUnit'
                    cp @teamCityAddinPath + '-2.4.8.*', 'lib/nunit/addins'
                end

		@nunitExe = File.join('lib', 'nunit', "nunit-console#{(@compilePlatform.empty? ? '' : "-#{@compilePlatform}")}.exe").gsub('/','\\') + ' /nothread'
        @ncoverExe = File.join('lib','ncover','ncover.console.exe') + ' ' + @nunitExe
         @ncoverExplorer= File.join('lib','ncover','ncoverexplorer.console.exe')
	end
	
	def executeTests(assemblies)
		Dir.mkdir @resultsDir unless exists?(@resultsDir)
		
		assemblies.each do |assem|
			file = File.expand_path("#{@sourceDir}/#{assem}/bin/#{@compileTarget}/#{assem}.dll")
			sh "#{@nunitExe} #{file}"
		end
	end
	def executeTestsWithCoverage(assemblies)
		Dir.mkdir @resultsDir unless exists?(@resultsDir)
        @coverageFileSuffix="-CoverageResults.xml"
		assemblies.each do |assem|
			file = File.expand_path("#{@sourceDir}/#{assem}/bin/#{@compileTarget}/#{assem}.dll")
			sh "#{@ncoverExe} \"#{file}\" //a #{@coverageAssemblies} //x "+File.join(@resultsDir,"#{assem}#{@coverageFileSuffix}")
        end

            sh "#{@ncoverExplorer} " +File.join(@resultsDir,"*#{@coverageFileSuffix}")+" /p:#{@projectName} /r:ModuleClassFunctionSummary /m:#{@minimumCoverage} /h:\"" +File.join(@resultsDir,"CoverageReport.html")+"\""
	end
end

class MSBuildRunner
	def self.compile(attributes)
		version = attributes.fetch(:clrversion, 'v3.5')
		compileTarget = attributes.fetch(:compilemode, 'debug')
	    solutionFile = attributes[:solutionfile]
		
		frameworkDir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', version)
		msbuildFile = File.join(frameworkDir, 'msbuild.exe')
		
		sh "#{msbuildFile} #{solutionFile} /nologo /maxcpucount /v:m /property:BuildInParallel=false /property:Configuration=#{compileTarget} /t:Rebuild"
	end
end

class AspNetCompilerRunner
	def self.compile(attributes)
		
		webPhysDir = attributes.fetch(:webPhysDir, '')
		webVirDir = attributes.fetch(:webVirDir, 'This_Value_Is_Not_Used')
		
		frameworkDir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', 'v2.0.50727')
		aspNetCompiler = File.join(frameworkDir, 'aspnet_compiler.exe')

		sh "#{aspNetCompiler} -nologo -errorstack -c -p #{webPhysDir} -v #{webVirDir}"
	end
end

class AsmInfoBuilder
	attr_reader :buildnumber, :parameterless_attributes

	def initialize(version, properties)
		@properties = properties
		@buildnumber = version
		@properties['Version'] = @properties['InformationalVersion'] = buildnumber;
		@parameterless_attributes = [:allow_partially_trusted_callers]
	end

	def write(file)
		template = %q{using System.Reflection;
using System.Security;

<% @properties.each do |k, v| %>
<% if @parameterless_attributes.include? k %>
[assembly: <%= k.to_s.camelize %>]
<% else %>
[assembly: Assembly<%= k.to_s.camelize %>("<%= v %>")]
<% end %>
<% end %>
		}.gsub(/^    /, '')

	  erb = ERB.new(template, 0, "%<>")

	  File.open(file, 'w') do |file|
		  file.puts erb.result(binding)
	  end
	end
end

def create_zip(filename, root, excludes=/^$/)
  File.delete(filename) if File.exists? filename
  @sevenZipExe=File.join('lib','7zip','7za.exe')
  sh "#{@sevenZipExe} a #{filename} ./#{root}/*"
end