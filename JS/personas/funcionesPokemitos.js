function listaPokemon(arrayPokemon) {
    let listaPokemitos = document.getElementById("listaPokemitos");
    for (let i = 0; i < arrayPokemon.results.length; i++) {
        let pokemon = arrayPokemon.results[i];
        let li = document.createElement("li");
        li.textContent = (i + 1) + ":    "+ pokemon.name;
        listaPokemitos.appendChild(li);
        li.addEventListener("click", function() {
            showDatos(pokemon);
        });
    }
  
}

function pedirDatos() {
    var miLlamada = new XMLHttpRequest();

    let url = "https://pokeapi.co/api/v2/pokemon?limit=20&offset=0";

    miLlamada.open("GET", url);


    miLlamada.onreadystatechange = function () {
        if (miLlamada.status == 200 || miLlamada.status == 201) {
            // Parseamos la respuesta JSON
            var arrayPokemon = JSON.parse(miLlamada.responseText);
            listaPokemon(arrayPokemon);
        } else {
            console.log(":(");
        }
    };

    miLlamada.send();
}

function showDatos(pokemon){

    var miLlamada = new XMLHttpRequest();

    let url = pokemon.url;

    miLlamada.open("GET", url);


    miLlamada.onreadystatechange = function () {
        if (miLlamada.status == 200 || miLlamada.status == 201) {
            // Parseamos la respuesta JSON
            var pokemon = JSON.parse(miLlamada.responseText);
            masDatos(pokemon);


        } else {
            console.log(":(");
        }
    };

    miLlamada.send();

}

function masDatos(pokemon){
    let a = document.getElementById("a");
    a.innerHTML = ""; 
    let imgFrontal = document.createElement("img");
    imgFrontal.src =  pokemon.sprites.front_default
    a.appendChild(imgFrontal);
}
   

function pedirDatosPersonas() {
    var miLlamada = new XMLHttpRequest();

    let url = "https://joseluisasp.azurewebsites.net/api/personas";

    miLlamada.open("GET", url);


    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            
            }else if (miLlamada.readyState == 4 && miLlamada.status == 200) { 
                    // Parseamos la respuesta JSON
                    var arrayPersonas = JSON.parse(miLlamada.responseText);
                    listaPersonas(arrayPersonas);
                } else {
                    console.log(":(");
            }
            
    };

    miLlamada.send();
}

function listaPersonas(arrayPersonas) {
    let listaPersonitas = document.getElementById("listaPersonitas");
    for (let i = 0; i < arrayPersonas.length; i++) {
        let persona = arrayPersonas[i];
        let li = document.createElement("li");
        li.id = "persona" + persona.id
        li.textContent = (i + 1) + ":    "+ persona.nombre;
        listaPersonitas.appendChild(li);
        li.addEventListener("click", function() {
            borraPersona(persona);
        });
    }
  
}

function borraPersona(persona){
    var confirmacion = confirm("¿Seguro que lo quiere borrar?");

    if(confirmacion){
        var miLlamada = new XMLHttpRequest();
        let url = "https://joseluisasp.azurewebsites.net/api/personas/" + persona.id;
    
    
        miLlamada.open("DELETE", url);
        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
    
                    //aquí se puede poner una imagen de un reloj o un texto “Cargando”
                    
                    }else if (miLlamada.readyState == 4 && miLlamada.status == 200) { 
                            alert("Persona borrada con éxito.")
                            // Localizar el contenedor de la lista
                    let listaPersonitas = document.getElementById("listaPersonitas");
    
                    // Localizar el elemento de la persona dentro de la lista
                    let elementoPersona = document.getElementById("persona" + persona.id);
    
                    // Eliminar el elemento de la lista en el HTML
                    if (elementoPersona) {
                        listaPersonitas.removeChild(elementoPersona);
                }
                    } else {
                        console.log(":(");
                }
        };
    
        miLlamada.send();
    }else{
        alert("Cancelado.")
    }
    

}

