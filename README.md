# CNNTweets
CNNTweets is web application developed using C# .Net. CNNTweets uses Twitter API to fetch 10 latest tweets from CNN twitter profile and display them to users. Users can modify and save fetched data to json file. Users also have an opportunity to translate tweets to Bosnian language thanks to Microsoft Translator, an AI service for real-time text and document translation.

# Steps to deploy an application to Microsoft Azure:
1. Open the application in Visual Studio
2. Right click on Project and click „Publish“
3. Select a publish target to “Azure”
4. Set Specific target to „Azure App Service“
5. After selecting an Azure account in the top right corner, create a new Azure service by clicking on „+“ icon next to „App Service instances“
6. New window will pop up. Set preferred „Name“; set Subscription name as „Azure subscription 1“; Create new „Resource group“ and a new „Hosting Plan“ (set „Size“ to Free)
7. Click „Create“
8. Click „Next“
9. Choose „Publish“ and press „Finish“ 
10. After everything is ready, press „Publish“ to deploy the application to Azure 
11. In the hosting section you can find site url

To update deployed application, after some code changes, simply right click on the Project and press „Publish“. New Window will pop up. At the top there will be another „Publish“ button to press to update deployed application.
