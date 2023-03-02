// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//This script is used for header so when using phone it swtiches to menu
var SwitchMenuMobile = document.getElementById("SwitchMenuMobile");
var MenuMobile = document.getElementById("MenuMobile");

var ClassMenuMobile = MenuMobile.className

SwitchMenuMobile.addEventListener("click", function () {
    MenuMobile.className = "MenuMobile";
})
MenuMobile.addEventListener("click", function () {
    MenuMobile.className = "MenuMobile" + " CloseMenu";
    setTimeout(1000, function () {
        MenuMobile.className = "MenuMobile CloseMenu" + " None";
    })
})
