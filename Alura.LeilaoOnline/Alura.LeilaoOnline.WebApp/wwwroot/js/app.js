function clickSeguir(e) {
    e.preventDefault();
    const link = $(e.target).parent();

    seguirLeilao(
        $(link).data(),
        function () {
            M.toast({ html: 'Agora você está seguindo o leilão!' });
            //mudar texto, classes e evento
            e.target.textContent = 'Abandonar!';
            $(e.target).removeClass("seguir");
            $(e.target).addClass("abandonar white-text text-darken-4");
            $(e.target).one('click', clickAbandonar);
        }
    );
}

function clickAbandonar(e) {
    e.preventDefault();

    const link = $(e.target).parent();

    //enviar requisição para deixar de seguir o leilão
    abandonarLeilao(
        $(link).data(),
        function () {
            M.toast({ html: 'Você deixou de seguir o leilão!' });
            //mudar o texto, classe e evento
            e.target.textContent = 'Seguir!';
            $(e.target).removeClass("abandonar yellow-text text-darken-4");
            $(e.target).addClass("seguir white-text");
            $(e.target).one('click', clickSeguir);
        }
    );
}

function seguirLeilao(dados, onsucess, onerror) {
    $.post(
        '/Interessadas/SeguirLeilao',
        dados,
        onsucess,
        onerror
    );
}

function abandonarLeilao(dados, onsucess, onerror) {
    $.post(
        '/Interessadas/AbandonarLeilao',
        dados,
        onsucess,
        onerror
    );
}