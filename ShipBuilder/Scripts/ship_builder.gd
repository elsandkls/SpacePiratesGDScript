extends Node2D

var core_click_count: int = 0
var weapon_click_count: int = 0
var engine_click_count: int = 0
var cockpit_click_count: int = 0
var cargo_click_count: int = 0 

func _core_button_core_pressed() -> void: 
	var AnimSprite = get_node("/root/ShipBuilder/GridContainer/BoxContainer_CENTER/AnimatedSprite2D_CENTER_USABLE") 
	var AnimSprite2 = get_node("/root/ShipBuilder/GridContainer/BoxContainer_CENTER/AnimatedSprite2D_CENTER") 
	if core_click_count == 0:
		AnimSprite.hide()
		AnimSprite2.show()
		core_click_count = 1
	else:	
		AnimSprite.show()
		AnimSprite2.hide()
		core_click_count = 0
	pass # Replace with function body.


func _engine_button_engine_pressed() -> void: 
	var AnimSprite = get_node("/root/ShipBuilder/GridContainer/BoxContainer_BOTTOM/AnimatedSprite2D_BOTTOM_USABLE") 
	var AnimSprite2 = get_node("/root/ShipBuilder/GridContainer/BoxContainer_BOTTOM/AnimatedSprite2D_BOTTOM") 
	if engine_click_count == 0:
		AnimSprite.hide()
		AnimSprite2.show()
		engine_click_count = 1
	else:	
		AnimSprite.show()
		AnimSprite2.hide()
		engine_click_count = 0
	pass # Replace with function body.


func _weapons_button_weapons_pressed() -> void:
	var AnimSprite = get_node("/root/ShipBuilder/GridContainer/BoxContainer_RIGHT/AnimatedSprite2D_RIGHT_USABLE") 
	var AnimSprite2 = get_node("/root/ShipBuilder/GridContainer/BoxContainer_RIGHT/AnimatedSprite2D_RIGHT") 
	if weapon_click_count == 0:
		AnimSprite.hide()
		AnimSprite2.show()
		weapon_click_count = 1
	else:	
		AnimSprite.show()
		AnimSprite2.hide()
		weapon_click_count = 0
	pass # Replace with function body.


func _cockpit_button_cock_pit_pressed() -> void:
	var AnimSprite = get_node("/root/ShipBuilder/GridContainer/BoxContainer_TOP/AnimatedSprite2D_TOP_USABLE") 
	var AnimSprite2 = get_node("/root/ShipBuilder/GridContainer/BoxContainer_TOP/AnimatedSprite2D_TOP") 
	if cockpit_click_count == 0:
		AnimSprite.hide()
		AnimSprite2.show()
		cockpit_click_count = 1
	else:	
		AnimSprite.show()
		AnimSprite2.hide()
		cockpit_click_count = 0
	pass # Replace with function body.


func _cargo_button_cargo_left_pressed() -> void:
	var AnimSprite = get_node("/root/ShipBuilder/GridContainer/BoxContainer_LEFT/AnimatedSprite2D_LEFT_USABLE") 
	var AnimSprite2 = get_node("/root/ShipBuilder/GridContainer/BoxContainer_LEFT/AnimatedSprite2D_LEFT") 
	if cargo_click_count == 0:
		AnimSprite.hide()
		AnimSprite2.show() 
		cargo_click_count = 1
	else:	
		AnimSprite.show()
		AnimSprite2.hide()
		cargo_click_count = 0
	pass # Replace with function body.


func _save_button_save_pressed() -> void:
	pass # Replace with function body.
