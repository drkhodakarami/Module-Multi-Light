# Module Multi Light
Stock KSP game has a ModuleLight. Let's have an example, think about a part that will sit on the surface of your vessle and behave like a mountable four direction light. Naturally you would have four spot lights in the modeling phase. You would like to turn all four of them on or off at the same time. Also, you would prefer to make all four lights blink at the same time.
The stock ModuleLight, will only accept a single light geometry from your model. So, you would have to add four ModuleLights to your part file to handle all four spot lights. This will cause a huge headache for you.
Using four ModuleLigths, means that now, in the part action window, you will have four buttons for turning lights on/off, and four buttons to make them blink. Unless you bind these actions to an action group, this won't work as intended. Also, now you would have four light color options.
In some cases that is exactly what you need, then by all means, use the stock module. How ever, if you want to turn many light objects on/off and blink syncronously with a single button click, this little module is for you.
## How to use
The syntax is similar to ModuleLight, how ever, when you have lightName in ModuleLight with a single name of the object, here you can have as many objects as you want, separate names with a comma and you can even use single space between comma and names to make things readable more.
The final result will be something like this :
```
MODULE
{
	name = ModuleMultiLight
	lightName = light_obj_1, light_obj_2, light_obj_3, light_obj_4, light_obj_5, light_obj_6, light_obj_7, light_obj_8
	lightRange = 10;
	useAnimationDim = True
		animationName = ANIM_NAME_TURN_ON
		lightBrightenSpeed = 2.5
		lightDimSpeed = 2.5
	disableColorPicker = False
		toggleInEditor = True
		toggleInFlight = True
	canBlink = True
		blinkMin = 0.2
		blinkMax = 2.0
		blinkRate = 0.5
		isBlinking = False
	useResources = True
		resourceName = ElectricCharge
		resourceAmount = 0.002
}
```
Notic, beside having many object names, now you have one additional parameter that you can set, the light's range value! The default number for this value is set to 60. This default value would work properly in case you have one or two ligths, but with more lights in close space, you may want to tweak and nerf this value down like this example.
Keep in mind, the license is MIT. If I was not able to keep this repo uptodate in future for next versions of game, anyone who wants to maintain this is already have permission!
