# Projects
My official repository to hold the projects that I am proud of and want to share.

## Base Builder Tool
I made the base builder tool in Unity to see if I could make a dynamic tool that anyone could incorporate into their game. I learned how to reference instantiated objects and their properties. I want to turn this tool into a script that can be toggled on and off so the user can switch between gameplay and base building in an instant. I intend to release this project along with instructions on how it works, and how to set it up to the user's preferences. This project isn't finished yet since I want to add lots of features that can be turned on and off for the user. I will continue working on this for about a month before moving onto another project. If someone has any requests for changes, or if they want additional features I am willing to work on this project again.

### Controller
The controller is the main code overseeing how the base builder tool functions. This will include variables that the developer can change without needing to access code as well as the ability to add any number of objects from the UI of Unity. This simple tool can be changed for the more advanced developer if they desire which is totally intentional. I left the code quite readable in the event that a developer sees the need to make any changes in the code.

### Phantom
This is a small peice of code for the object when it is hovering and following the mouse. This script should only be active on one object at a time and should only be activated by the controller.