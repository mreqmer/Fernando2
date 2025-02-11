import { Component, OnInit } from '@angular/core';
import { Persona } from '../interfaces/persona';
import { PersonasService } from '../services/personas.service';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource } from '@angular/material/table';
import {MatIcon} from '@angular/material/icon'; // Si deseas usar ordenación


@Component({
  selector: 'app-listado-personas',
  imports: [
    CommonModule,
    MatTableModule,
    MatToolbarModule,
    MatButtonModule, MatIcon
  ],
  templateUrl: './listado-personas.component.html',
  styleUrl: './listado-personas.component.css'
})

export class ListadoPersonasComponent implements OnInit {

  listadoPersonas: MatTableDataSource<Persona> ;
  displayedColumns: string[] = ['id', 'nombre', 'apellidos'];
  
  constructor(private personasServicio: PersonasService) { }
  
  ngOnInit(): void {
  
  this.obtenerPersonas();
  }

  async obtenerPersonas() {

    this.personasServicio.getPersonas().subscribe({
    
    next:(response) =>{
    
    this.listadoPersonas= new MatTableDataSource<Persona>(response);
    
    },
    
    error: (error)=>{
    
    alert("Ha ocurrido un error al obtener los datos del servidor");
    
    }
    
    });
    
    }
  
  }
