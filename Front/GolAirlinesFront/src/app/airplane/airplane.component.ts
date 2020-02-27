import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators, FormBuilder} from "@angular/forms";
import {Router, ActivatedRoute} from "@angular/router";

import { Airplane } from 'src/app/models/airplane';
import { AirplanesService } from 'src/app/services/airplanes.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styleUrls: ['./airplane.component.css']
})
export class AirplaneComponent implements OnInit {
  public displayMessage:string;
  constructor(
    private airplaneService: AirplanesService,
    private formBuilder: FormBuilder,
    private router: Router,
    private toastrService: ToastrService,
    private route: ActivatedRoute
  ) { 
    this.buildForm();
  }

  displayTitle: string;
  idAirplane: number;
  customForm: FormGroup;

  cadastrar = () => {
    let airplane = new Airplane();
    airplane.modelo = this.customForm.value.modelo;
    airplane.quantidadePassageiros = this.customForm.value.quantidadePassageiros;
    
    this.airplaneService.addAirplane(airplane).subscribe((response) =>{
      if(response.sucesso){
        this.router.navigate(['airplanes']);
        this.toastrService.success("Operação realizado com sucesso!");
      }
      else{
        console.log(response);
        response.inconsistencias.forEach(element => {
          this.toastrService.error(element);
        });
      }
    });
  }

  alterar = () => {
    let airplane = new Airplane();
    airplane.codigoDoAviao = this.customForm.value.codigoDoAviao;
    airplane.modelo = this.customForm.value.modelo;
    airplane.quantidadePassageiros = this.customForm.value.quantidadePassageiros;

    this.airplaneService.updateAirplane(airplane).subscribe((response) =>{
      if(response.sucesso){
        this.router.navigate(['airplanes']);
        this.toastrService.success("Operação realizado com sucesso!");
      }
      else{
        response.inconsistencias.forEach(element => {
          this.toastrService.error(element);
        });
      }
    });
  }

  voltar = () =>{
    this.router.navigate(['airplanes']);
  }

  onSalvar = () =>{
    if(this.idAirplane > 0){
      this.alterar();
    }else{
      this.cadastrar();
    }
  }

  buildForm = () => {
      this.customForm = new FormGroup({
        codigoDoAviao: new FormControl(0),
        modelo: new FormControl(1, [Validators.required]),
        quantidadePassageiros: new FormControl(0, [Validators.required]),
      });
  }

  ngOnInit() {
    this.displayTitle = "Adicionar";
    this.route.params.subscribe(params => {
       this.idAirplane = +params['id'];
    });

    if(this.idAirplane > 0){
      this.displayTitle = "Alterar";
      this.airplaneService.getAirplaneById(this.idAirplane).subscribe((response) =>{
        if(response != null){
          this.customForm.setValue({
            codigoDoAviao : response.codigoDoAviao,
            modelo: response.modelo,
            quantidadePassageiros: response.quantidadePassageiros
          });
        }
      });
    }
  }
}
