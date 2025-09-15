extends Camera2D

# 缩放的灵敏度
@export var zoom_sensitivity := 0.1
# 最小缩放值
@export var min_zoom := 0.1
# 最大缩放值
@export var max_zoom := 5.0

func _input(event):
	# 检测鼠标滚轮事件
	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_WHEEL_DOWN:
		# 滚轮向上 - 放大
		zoom = Vector2(
			clamp(zoom.x - zoom_sensitivity, min_zoom, max_zoom),
			clamp(zoom.y - zoom_sensitivity, min_zoom, max_zoom)
		)
		# 确保事件被处理
		
		
	elif event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_WHEEL_UP:
		# 滚轮向下 - 缩小
		zoom = Vector2(
			clamp(zoom.x + zoom_sensitivity, min_zoom, max_zoom),
			clamp(zoom.y + zoom_sensitivity, min_zoom, max_zoom)
		)
		# 确保事件被处理
