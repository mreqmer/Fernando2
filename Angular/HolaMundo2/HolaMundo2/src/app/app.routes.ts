import { Routes } from '@angular/router';
import { TablaPersonasComponent } from './tabla-personas/tabla-personas.component';
import { FormularioComponent } from './formulario/formulario.component';
import { EnlacesComponent } from './enlaces/enlaces.component';

export const routes: Routes = [
    
    {path: 'tabla', component: TablaPersonasComponent},
    {path: 'formulario', component: FormularioComponent},
    {path: 'enlaces', component: EnlacesComponent}
];

