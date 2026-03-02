extends Node2D


func _on_start_game_button_pressed() -> void:
	get_tree().change_scene_to_file("res://SolarSystems/Scenes/SolarSystem_00.tscn") 
	pass # Replace with function body.


func _on_ship_builder_button_pressed() -> void:
	get_tree().change_scene_to_file("res://ShipBuilder/Scenes/ShipBuilder.tscn") 
	pass # Replace with function body.


func _on_save_game_button_pressed() -> void:
	get_tree().change_scene_to_file("res://Menus/Scenes/SaveMenu.tscn") 
	pass # Replace with function body.


func _on_settings_button_pressed() -> void:
	get_tree().change_scene_to_file("res://Menus/Scenes/SettingsMenu.tscn") 
	pass # Replace with function body.
