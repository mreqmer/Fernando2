import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { importProvidersFrom } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';

bootstrapApplication(AppComponent, {
  providers: [
    provideAnimations(), // Para animaciones de Angular Material
    provideHttpClient(), // Si necesitas HttpClient
    importProvidersFrom(MatButtonModule) // Importa módulos de Angular Material
  ]
});

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
