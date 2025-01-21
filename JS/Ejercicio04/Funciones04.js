

function recorreCeldas(){

    let tabla = document.getElementById("tabla");

    let filas = tabla.getElementsByTagName("tr");
    let celdas;

    filas.array.forEach(element => {
        celdas = element.getElementsByTagName('td');
        console.log(element.getElementsByTagName('td'))
    });

    

}