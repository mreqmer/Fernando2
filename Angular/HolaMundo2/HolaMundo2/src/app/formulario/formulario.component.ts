import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-formulario',
  imports: [ReactiveFormsModule,  CommonModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent implements OnInit {
  formulario: FormGroup;

  constructor() {

  }
  
  ngOnInit(): void {
  
  this.formulario=new FormGroup(
  
  {
  
  nombre: new FormControl('',[Validators.required]),
  
  apellidos:new FormControl('',[Validators.required])
  
  }
  
  );
  
  
  }

  

  saluda(): void {
    const nombre = this.formulario.get('nombre')!.value;
    const apellidos = this.formulario.get('apellidos')!.value;
    alert(`Hola ${nombre} ${apellidos}`); 
  }
}