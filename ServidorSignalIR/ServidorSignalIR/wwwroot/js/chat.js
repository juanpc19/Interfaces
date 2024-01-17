class clsMensajeUsuario {
    constructor(nombreUsuario, mensajeUsuario) {
        this.nombreUsuario = nombreUsuario;
        this.mensajeUsuario = mensajeUsuario;
    }
 }

"use strict";

 //conexion con el hub
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


//recibir mensaje
//connection.on("ReceiveMessage", function (user, message) {
connection.on("ReceiveMessage", function (mensaje) {

    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you
    // should be aware of possible script injection concerns.

    //li.textContent = `${user} says ${message}`;
    li.textContent = `${mensaje.nombreUsuario} says ${mensaje.mensajeUsuario}`;
});

//habilitar el boton de enviar cuando se establece la conexion
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

//enviar mensaje
document.getElementById("sendButton").addEventListener("click", function (event) {

    nombreUsuario = document.getElementById("userInput").value;
    mensajeUsuario = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", mensaje.nombreUsuario, mensaje.mensajeUsuario).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

