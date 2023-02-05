function white() {
	var element = document.getElementById("changeTheme");
	element.classList.add("white");
	element.classList.remove("black","purple");
}
function black() {
	var element = document.getElementById("changeTheme");
	element.classList.add("black");
	element.classList.remove("white","purple");
}
function purple() {
	var element = document.getElementById("changeTheme");
	element.classList.add("purple");
	element.classList.remove("white","black");
}
