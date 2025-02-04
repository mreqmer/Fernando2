//Cambiar según el puerto
const url = "https://localhost:7237/API/"

/**
 * Conecta con la api para obtener el listado de departamento, además si es exitoso llama a listarDepartamentos
 */
function pedirListaDept() {
    var miLlamada = new XMLHttpRequest();
    let urlDepartamento = url + "Departamentos"
    miLlamada.open("GET", urlDepartamento);
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            //poner algo mientras carga
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            // Parseamos la respuesta JSON
            let listaDepartamentos = JSON.parse(miLlamada.responseText);
            listarDepartamentos(listaDepartamentos);
        } else {
            console.log(":(");
        }

    };

    miLlamada.send();
}

/**
 * A partir de un listado de departamentos los lista, añadiéndolos a una ul de la vista
 * NOTA: no me acordaba de hacer un desplegable así que hice una lista con un evento de click
 * @param {any} listaDepartamentos
 */
function listarDepartamentos(listaDepartamentos) {

    let listado = document.getElementById("listaDepartamento");
    listado.innerHTML = "";
    for (let i = 0; i < listaDepartamentos.length; i++) {
        let departamento = listaDepartamentos[i];
        let li = document.createElement("li");
        li.textContent = departamento.idDepartamento + ". " + departamento.nombreDepartamento;
        listado.appendChild(li);
        li.addEventListener("click", function () {
            obtienePersonasDepartamento(departamento.idDepartamento);
        });
    }
}

/**
 * Hace una llamada para obtener las personas que pertenecen a un departamento
 * @param {any} idDepartamento
 */
function obtienePersonasDepartamento(idDepartamento) {
    var miLlamada = new XMLHttpRequest();
    let urlPersonasDepartamento = url + "Departamentos/" + idDepartamento + "/Personas";
    miLlamada.open("GET", urlPersonasDepartamento);
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            //poner algo mientras carga
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            // Parseamos la respuesta JSON
            let listaPersonasDepartamentos = JSON.parse(miLlamada.responseText);
            muestraTablaPersonas(listaPersonasDepartamentos);
        } else {
            console.log(":(");
        }

    };

    miLlamada.send();
}

/**
 * Muesta la cabecera tabla de personas cuando se hace click en un departamento
 * @param {any} personas
 */
function muestraTablaPersonas(personas) {
    let divTablaPersonas = document.getElementById("tablaPersonasDepartamento");
    divTablaPersonas.innerHTML = "";
    divTablaPersonas.innerHTML = `
                     <table>
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Apellidos</th>
                            </tr>
                        </thead>
                        <tbody id="tbody">
                        </tbody>
                    </table>
                `;
    let tbody = document.getElementById("tbody");
    tbody.innerHTML = "";
    addPersonasTabla(personas);
    
}
/**
 * añade personas a la tabla
 * NOTA: no tengo ni idea de porqué solo me funcionan con las últimas personas de la tabla
 * @param {any} personas
 */
function addPersonasTabla(personas) {
    for (let i = 0; i < personas.length; i++) {
        let persona = personas[i];
        tbody.innerHTML += `
                    <tr id="persona${persona.idPersona}">
                        <td>${personas[i].nombre}</td>
                        <td>${personas[i].apellidos}</td>
                    </tr>
                `;
        let tr = document.getElementById("persona" + persona.idPersona)
        tr.addEventListener("click", function () {
            showPersona(persona);
        });
    }
}

/**
 * Muestra la info de una persona cuando se le hace click
 * @param {any} persona
 */
function showPersona(persona) {
    console.log(persona.nombre)
    let divDatosPersona = document.getElementById("datosCompletoPersona");
    
    divDatosPersona.innerHTML = `
    <p>ID: " ${persona.idPersona}<p>
    <p>Nombre: ${persona.nombre}<p>
    <p>Apellidos: ${persona.apellidos }<p>
    <p>Fecha Nacimiento: ${persona.fechaNac}<p>
    <p>telefono: ${persona.telefono}<p>
    <p>direccion: ${persona.direccion}<p>
    `

}

//Ejecuta los elementos que deben estar cargados al iniciar la vista
document.addEventListener(

    'DOMContentLoaded', function () {
        pedirListaDept();
    }
    )