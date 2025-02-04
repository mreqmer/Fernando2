import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'Mi Aplicación';
  constructor(private router: Router) {}

  GoToFormulario(): void {
    this.router.navigate(['/formulario']);
    alert("Hola Mundo");
  }
}