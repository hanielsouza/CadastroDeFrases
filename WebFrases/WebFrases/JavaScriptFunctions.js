function ShowMsg(titulo, texto) {
    document.getElementById("cxFloatMsg").style.display = "block";
    document.getElementById("msgTitulo").innerText = titulo;
    document.getElementById("msgTexto").innerText = texto;
}

function HideMsg() {
    document.getElementById("cxFloatMsg").style.display = "none";
}

function novajan() {
    window.open("sucesso.asp", "Erro", "width=240,height=240,scrollbar=no,status=yes,resize=no")
}

function fechapop() {
    window.setTimeout("window.close()", 10000);
}

