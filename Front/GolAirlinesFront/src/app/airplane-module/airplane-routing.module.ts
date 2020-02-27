import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AirplaneListComponent } from '../airplane-list/airplane-list-component';
import { AirplaneComponent } from '../airplane/airplane.component';

const routes: Routes = [
  { 
    path: '', 
    component: AirplaneListComponent 
  },
  {
    path: 'airplane',
    component: AirplaneComponent
  },
  {
    path: 'airplane/:id',
    component: AirplaneComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AirplaneRoutingModule { }
