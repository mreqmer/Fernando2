
class Persona{
    constructor(nombre, apellidos){
        this.nombre = nombre,
        this.apellidos = apellidos
    }
}

function submitPersona(){

    let nombre = document.getElementById("name").value;
    let apellidos = document.getElementById("apellidos").value;

    let persona = new Persona(nombre, apellidos);

    alert("Nombre: " + persona.nombre + "\nApellido: " + persona.apellidos);
    console.log(persona.nombre, persona.apellidos);

}