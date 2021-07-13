function readPosterURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgPoster').attr('src', e.target.result);
            $('.imagem .card-content').text(input.files[0].name);
            console.log(input.files[0].name);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

(function ($) {
    $(function () {

        $('.sidenav').sidenav();
        $('.parallax').parallax();
        $(".dropdown-trigger").dropdown({
            hover: true,
            constrainWidth: false,
            coverTrigger: false
        });
        $('.carousel.carousel-slider').carousel({
            fullWidth: true,
            indicators: true
        });
        $('.modal').modal();
        $('select').formSelect();
        $('.datepicker').datepicker({
            "format": "dd/mm/yyyy",
            autoClose: true
        });
        $('#ArquivoImagem').change(function () {
            readPosterURL(this);
        });
        $('.tooltiped').tooltip();
        $('input[type=text]:not(.browser-default), textarea').characterCounter();

        $('#btnDarLance').on('click', darLance);
        $('.seguir').one('click', clickSeguir);
        $('.abandonar').one('click', clickAbandonar);

    }); // end of document ready
})(jQuery); // end of jQuery name space
