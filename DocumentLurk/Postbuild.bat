setlocal
cd %~dp0

echo Convert documents to TXT, XML and HTML formats

echo architecture
 rfctool C:\Users\Phillip\OneDrive\Documents\IETF\hallambaker-lurk.docx ^
 	/html Publish\hallambaker-lurk.html ^
	/xml Publish\hallambaker-lurk.xml ^
 	/txt Publish\hallambaker-lurk.txt


exit /b 0