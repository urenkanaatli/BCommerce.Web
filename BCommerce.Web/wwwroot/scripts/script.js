
function initMap() { var elements = document.querySelectorAll('.js-map'); Array.prototype.forEach.call(elements, function (el) { var lat = +el.dataset.latitude, lng = +el.dataset.longitude, zoom = +el.dataset.zoom; if ((lat !== '') && (lng !== '') && (zoom > 0)) { var map = new google.maps.Map(el, { zoom: zoom, center: { lat: lat, lng: lng }, disableDefaultUI: true }); var marker = new google.maps.Marker({ map: map, animation: google.maps.Animation.DROP, position: { lat: lat, lng: lng } }); } }); }
(function () {
    var container = document.getElementById('products'); if (container) {
        var grid = container.querySelector('.js-products-grid'), viewClass = 'tm-products-', optionSwitch = Array.prototype.slice.call(container.querySelectorAll('.js-change-view a')); function init() { optionSwitch.forEach(function (el, i) { el.addEventListener('click', function (ev) { ev.preventDefault(); _switch(this); }, false); }); }
        function _switch(opt) { optionSwitch.forEach(function (el) { grid.classList.remove(viewClass + el.getAttribute('data-view')); }); grid.classList.add(viewClass + opt.getAttribute('data-view')); }
        init();
    }
})(); function increment(incrementor, target) {
    var value = parseInt(document.getElementById(target).value, 10); value = isNaN(value) ? 0 : value; if (incrementor < 0) { if (value > 1) { value += incrementor; } } else { value += incrementor; }
    document.getElementById(target).value = value;
}
(function () {

    UIkit.scroll('.js-scroll-to-description', { duration: 300, offset: 58 });
})();



})();