import { Component, OnInit } from '@angular/core';
import { Airplane } from 'src/app/models/airplane';
import { AirplanesService } from 'src/app/services/airplanes.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-airplane-list',
  templateUrl: './airplane-list-component.html',
  styleUrls: ['./airplane-list-component.css']
})

export class AirplaneListComponent implements OnInit {
  airplanes : Airplane[];
  constructor(
    private airplaneService: AirplanesService,
    private router : Router
  ) { }

  getAirplanes = () => {
    this.airplaneService.getAirplane().subscribe((response)=> {
      this.airplanes = response;
    });
  }

  onExcluir = (codAviao: number) => {
    if(confirm("Deseja Realmente Excluir esse avião ?")){
      this.airplaneService.excluirAirplane(codAviao).subscribe((response) =>{
        this.getAirplanes();
      });
  
    }
  }

  onCadastrar = () => {
    this.router.navigate(['airplane']);
  }

  onAlterar = (idAirplane: number) => {
    this.router.navigate([`airplane/${idAirplane}`]);
  }

  ngOnInit() {
    this.getAirplanes();
  }
}
