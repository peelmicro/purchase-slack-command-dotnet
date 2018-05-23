# Purchase Slack Command

This is the code adapted to .Net Core for the tutorial on _How to create a Slack bot to automate tasks for you_.

The key learnings of this course include:

* how to create a Slack command for Slack
* how to create an interactive message with buttons
* how to process a button being clicked in a Slack message
* how to send direct messages to users in Slack from a Slack bot
* how to persist state between messages using Firebase
* how to start implementing the logic of a personal assistant to remind users of actions they need to take

# Before executing it, setting credentials and variables must be updated

1st) Rename appsettings.Development.example.json to appsettings.Development.json

2nd) Update your own values

# add FirebaseDatabase to have access to Firebase database
dotnet add package FirebaseDatabase.net --version 3.3.3

# Follow the course on
https://www.udemy.com/how-to-create-a-slack-bot-to-automate-tasks-for-you