// Write your JavaScript code.

// Rende tutti i text di input uppercase sull' evento di cambio contenuto
// in questo modo anche con un copia incolla
// Utilizzato per il editformodel
$('input[type=text]').change(function () {
    $('input[type=text]').val(function () {
        return this.value.toUpperCase();
    })
});
