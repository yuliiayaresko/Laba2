<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h2>Список професорів</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Ім'я</th>
            <th>Факультет</th>
          </tr>
          <xsl:for-each select="professors/professor">
            <tr>
              <td><xsl:value-of select="@name"/></td>
              <td><xsl:value-of select="@faculty"/></td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
