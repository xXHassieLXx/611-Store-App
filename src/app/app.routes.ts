import { Routes } from '@angular/router';


// http://localhost:4200/ -> /admin
export const routes: Routes = [
    {path:"", redirectTo:"admin", pathMatch:"full"},
    {
        path: "",
        //Carga todas las rutas en el path
        //Se evita cargar componente por componente
        //y se carga el modulo completo
        //con todas sus rutas hijas
        //Lazy loading
        loadChildren: () => import('./pages/pages-module').then(m => m.PagesModule)
    }
];
