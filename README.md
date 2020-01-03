# upgraded-happiness
Interview question: Webservice to parse XML payload

## Question
Write a webservice that accepts the following XML document as the payload:

```
<InputDocument>
	<DeclarationList>
		<Declaration Command="DEFAULT" Version="5.13">
			<DeclarationHeader>
				<Jurisdiction>IE</Jurisdiction>
				<CWProcedure>IMPORT</CWProcedure>
							<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>
				<DocumentRef>71Q0019681</DocumentRef>
				<SiteID>DUB</SiteID>
				<AccountCode>G0779837</AccountCode>
			</DeclarationHeader>
		</Declaration>
	</DeclarationList>
</InputDocument>
```

The webservice should respond with a status code which is based on parsing the contents of the XML payload

a.	If the XML document is given here is passed then return a status of `0` – which means the document was structured correctly.

b.	If the Declararation’s Command <> `DEFAULT` then return `-1` – which means invalid command specified.

c.	If the SiteID <> `DUB` then return `-2` – invalid Site specified.

