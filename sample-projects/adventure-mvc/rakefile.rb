require "BuildUtils.rb"
require 'rubygems'

include FileTest


COMPILE_TARGET = "debug"
RESULTS_DIR = "results"
BUILD_NUMBER = "0.1.0."
PRODUCT = "AdventureMVC"
COPYRIGHT = 'Copyright 2009 Richard Cirerol, Aaron Jackson, Carlos Bittencourt, et al. All rights reserved.';
COMMON_ASSEMBLY_INFO = 'src/CommonAssemblyInfo.cs';
CLR_VERSION = "v3.5"

SOLUTION_FILE = 'src/AdventureMVC.sln'
#OUT_DIR =  "src/AdventureMVC/bin"
TESTS = ['AdventureMVC.Tests', 'AdventureMVC.Data.FluentNHibernate.Tests']
COVERAGE_ASSEMBLIES ="AdventureMVC.Tests;AdventureMVC.Core;AdventureMVC;AdventureMVC.Data;AdventureMVC.Data.FluentNHibernate.Tests"

versionNumber = ENV["BUILD_NUMBER"].nil? ? 0 : ENV["BUILD_NUMBER"]

props = { :archive => "build" }

desc "Compiles, unit tests, generates the database"
task :all => [:default]

desc "**Default**, compiles and runs tests"
task :default => [:compile, :unit_test, :zip_website]

desc "Displays a list of tasks"
task :help do
  taskHash = Hash[*(`rake -T`.split(/\n/).collect { |l| l.match(/rake (\S+)\s+\#\s(.+)/).to_a }.collect { |l| [l[1], l[2]] }).flatten]

  indent = "                          "

  puts "rake #{indent}#Runs the 'default' task"

  taskHash.each_pair do |key, value|
    if key.nil?
      next
    end
    puts "rake #{key}#{indent.slice(0, indent.length - key.length)}##{value}"
  end
end

desc "Update the version information for the build"
task :version do
  builder = AsmInfoBuilder.new(BUILD_NUMBER, {'Product' => PRODUCT, 'Copyright' => COPYRIGHT})
  buildNumber = builder.buildnumber
  puts "The build number is #{buildNumber}"
  builder.write COMMON_ASSEMBLY_INFO
end

desc "Prepares the working directory for a new build"
task :clean do
  #TODO: do any other tasks required to clean/prepare the working directory
  Dir.mkdir props[:archive] unless exists?(props[:archive])
end

desc "Compiles the app"
task :compile => [:clean, :version] do
  MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => SOLUTION_FILE, :clrversion => CLR_VERSION

  #outDir = "#{OUT_DIR}/#{COMPILE_TARGET}"
  #Dir.glob(File.join(, "*")){|file|
  #copy(file, props[:archive]) if File.file?(file)
  #}

end

desc "Runs unit tests"
task :test => [:unit_test]

desc "Runs unit tests"
task :unit_test => :compile do
  runner = NUnitRunner.new :compilemode => COMPILE_TARGET, :source => 'src', :platform => 'x86', :projectName => PRODUCT, :coverageAssemblies => COVERAGE_ASSEMBLIES, :minimumCoverage => '70'
  runner.executeTestsWithCoverage TESTS
end

desc "Target used for the CI server"
task :ci => [:unit_test]

desc "Zip up the Precompiled website"
task :zip_website => :compile do
  create_zip File.join(RESULTS_DIR, 'Artifacts.zip'), 'src/PrecompiledWeb/Web'
end