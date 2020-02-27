import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AirplaneRoutingModule } from './airplane-routing.module';
import { AirplaneListComponent } from '../airplane-list/airplane-list-component';
import { AirplaneComponent } from '../airplane/airplane.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AirplaneListComponent,
    AirplaneComponent
  ],
  imports: [
    CommonModule, 
    AirplaneRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})

export class AirplaneModule { }
