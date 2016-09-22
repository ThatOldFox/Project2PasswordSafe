# Project2PasswordSafe
Password Encrypting project for Mobile Computing
Our project allows a user to encrypt a username and password for an existing account and store it in a remote and local database
to implement the Remote database we used the an ASP.Net API which can be found here - https://github.com/ThatOldFox/PasswordSafeWEBAPI

this API requires .Net 4.5 to run due to the .Net cryptography reference we used 

Xamarin Application Development Enviroment
- Visual Studio Update 3
- Xamarin.Forms version=2.0.0.6482
- SQLite.Net-PCL version=3.1.1
- Newtonsoft.Json version=9.0.1
- PCLCrypto version=2.0.147

ASP.NET API Development Enviroment
- Visual Studio Update 3
- .NET Framework 4.5.2


API set up Visual Studio
- set your project url in the project properties to as follows http://YOUR_IP_ADDRESS:34592/ and replace your ip address with your ip   address

- Open the main project folder and go into the .VS file and open the config folder and file Vs folder may be hidden

- Find the tag that says <site name="ConferenceSessionAPIs" id="2"> and replace the two binding tags with these replacing your ip       address with the one you used in the first step
  <binding protocol="http" bindingInformation="*:34592:localhost" />
	<binding protocol="http" bindingInformation="*:34592:YOUR_IP_ADDRESS" />

- Finally open a cmd in administrator mode and insert the following commands Again replacing YOUR IP with the one used earlier

    > netsh http add urlacl url=http://YOUR_IP_ADDRESS:34592/ user=everyone

    > netsh advfirewall firewall add rule name="IISExpressWeb" dir=in protocol=tcp localport=34592 profile=private remoteip=localsubnet action=allow

It should be now set up thanks



References
Xamarin Application
- emailregex, 2016, Email Address Regular Expression That 99.99% Works,emailregex, Retrived 14/09/2016
  http://emailregex.com/ 

- Xamarin,2016,Xamarin.Forms.ActivityIndicator Class, Xamarin, Retrived 10/09/2016
  https://developer.xamarin.com/api/type/Xamarin.Forms.ActivityIndicator/

- Ford,K,2015,Xamarin.Forms removing a page,StackOverFlow,Retrived 08/09/2016
  http://stackoverflow.com/questions/29042792/xamarin-forms-removing-a-page

- Seridonio,P,2016,Cryptography Shared Code,Xamarin, Retrieved 10/09/2016 
  https://forums.xamarin.com/discussion/64399/cryptography-shared-code


ASP.Net API

- Wasson,M,2014,Attribute Routing in ASP.Net Web API 2, Microsoft, Retrived 09/09/2016
  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
  
- Administrator, 2011,Simple C#.Net Encryption and Decryption for String,Tech Example Retrived 11/09/2016
  http://www.techexample.com/simple-c-net-encryption-and-decryption-for-string/
