import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AirplaneComponent } from './airplane/airplane.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./airplane-module/airplane.module')
      .then(m => m.AirplaneModule)
  },
  {
    path: 'airplanes',
    loadChildren: () => import('./airplane-module/airplane.module')
      .then(m => m.AirplaneModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
