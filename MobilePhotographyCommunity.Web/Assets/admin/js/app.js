const btnToggleNavBar = document.getElementsByClassName('navbar-toggler')[0];
const menuNav = document.getElementById('collapse');
var collapseNavMenu = false;
btnToggleNavBar.addEventListener('click', function () {
    const navMenuCssClass = collapseNavMenu ? 'collapse' : null;
    collapseNavMenu = !collapseNavMenu;
    menuNav.className = navMenuCssClass;
});