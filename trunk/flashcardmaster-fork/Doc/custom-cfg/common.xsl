<?xml version="1.0" encoding="UTF-8"?>

<!-- This file is part of Dopus                                              -->

<!-- Dopus is free software; you can redistribute it and/or modify           -->
<!-- it under the terms of the GNU General Public License as published by    -->
<!-- the Free Software Foundation; either version 2 of the License, or       -->
<!-- (at your option) any later version.                                     -->

<!-- Dopus is distributed in the hope that it will be useful,                -->
<!-- but WITHOUT ANY WARRANTY; without even the implied warranty of          -->
<!-- MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           -->
<!-- GNU General Public License for more details.                            -->

<!-- You should have received a copy of the GNU General Public License       -->
<!-- along with Dopus; if not, write to the Free Software                    -->
<!-- Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA -->

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:fo="http://www.w3.org/1999/XSL/Format"
                version='1.0'>

  <xsl:param name="paper.type">USletter</xsl:param>
  <xsl:param name="page.orientation">portrait</xsl:param>
  <xsl:param name="chunk.first.sections">1</xsl:param>
  <xsl:param name="callout.list.table">0</xsl:param>
  <xsl:param name="chunker.output.indent">yes</xsl:param>
  <xsl:param name="graphicsize.extensions">1</xsl:param>
  <xsl:param name="toc.section.depth">1</xsl:param>
  <xsl:param name="menuchoice.menu.separator"> → </xsl:param>
  <xsl:param name="menuchoice.separator"> → </xsl:param>
  <!-- <xsl:param name="menuchoice.separator" select="' → '"/> -->
  <xsl:param name="blurb.on.titlepage.enabled">1</xsl:param>
  <xsl:param name="email.delimiters.enabled">1</xsl:param>
  <xsl:param name="formal.title.placement">
figure after
example after
equation after
table after
procedure after
task after
</xsl:param>
  
  
  <!-- <xsl:param name="htmlhelp.autolabel" select="0"/> -->

<xsl:param name="htmlhelp.button.next" select="1"/>
<xsl:param name="htmlhelp.button.options" select="1"/>
<xsl:param name="htmlhelp.button.prev" select="1"/>
<xsl:param name="htmlhelp.button.print" select="1"/>
<xsl:param name="htmlhelp.button.zoom" select="1"/>

<xsl:param name="htmlhelp.hhc.folders.instead.books" select="0"/>
<xsl:param name="htmlhelp.show.advanced.search" select="1"/>
<xsl:param name="htmlhelp.show.favorities" select="1"/>
<xsl:param name="htmlhelp.show.toolbar.text" select="1"/>

<xsl:param name="htmlhelp.button.jump1" select="1"/>
<xsl:param name="htmlhelp.button.jump1.title" select="'Home Page'"/>
<xsl:param name="htmlhelp.button.jump1.url">http://flashcardmaster.sourceforge.net/</xsl:param>



</xsl:stylesheet>
