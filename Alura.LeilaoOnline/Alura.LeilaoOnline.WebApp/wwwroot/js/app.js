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