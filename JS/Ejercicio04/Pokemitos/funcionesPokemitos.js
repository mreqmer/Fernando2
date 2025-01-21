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
    