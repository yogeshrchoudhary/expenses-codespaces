# Deployment notes
To ensure that events are logged in the Windows Event Viewer, the Event Source needs to be created.
This can be created by executing the below PowerShell command in Admin mode,
```ps
New-EventLog -Source "YourSource" -LogName Application
```
Replace "YourSource" with the name of the source you want to use for logging events. This command will create a new event source in the Application log, allowing your application to log events under that source name.