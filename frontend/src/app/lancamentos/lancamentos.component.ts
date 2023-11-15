import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpProviderService } from '../services/http-provider.service';
import { ToastrService } from 'ngx-toastr';
import * as moment from 'moment';
import { Lancamento } from '../models/Lancamento';
import { FiltroLancamento } from '../models/FiltroLancamento';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-lancamentos',
  templateUrl: './lancamentos.component.html',
  styleUrls: ['./lancamentos.component.scss'],
})
export class LancamentosComponent implements OnInit {
  lancamentos: Lancamento[] = [];
  total: number = 0;
  status: boolean = false;

  today: string = moment().format('YYYY-MM-DD');
  startDate: string = moment().add(-2, 'days').format('YYYY-MM-DD');
  endDate: string = moment().format('YYYY-MM-DD');

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private httpProvider: HttpProviderService
  ) {}

  ngOnInit() {
    this.listarTodos();
  }

  startDateHandleChange($event: any) {
    this.startDate = $event.target.value;
    this.listarTodos();
  }

  endDateHandleChange($event: any) {
    this.endDate = $event.target.value;
    this.listarTodos();
  }

  async listarTodos() {
    const filtro: FiltroLancamento = {
      dataInicial: this.startDate,
      dataFinal: this.endDate,
    };

    this.httpProvider.getAll(filtro).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.lancamentos = resultData.data;
          this.total = this.lancamentos
            .filter((l) => l.status == true)
            .reduce((sum, current) => sum + current.valor, 0);
        }
      }
    });
  }

  incluir() {
    this.router.navigate(['/Lancamentos/Incluir']);
  }

  editar(lancamento: Lancamento) {
    this.router.navigate(['/Lancamentos/Editar', lancamento.id]);
  }

  async cancelar(lancamento: Lancamento) {
    this.httpProvider.delete(lancamento.id).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData && resultData.success) {
          this.toastr.success(resultData.message);
          this.listarTodos();
        }
      }
    });
  }

  confirmarCancelamento(lancamento: Lancamento) {
    Swal.fire({
      title: 'Atenção!',
      text: 'Confirma o cancelamento deste lançamento?',
      icon: 'question',
      confirmButtonText: 'Sim',
      showCancelButton: true,
      cancelButtonText: 'Não',
    }).then((result: any) => {
      if (result.isConfirmed === true) {
        this.cancelar(lancamento);
      }
    });
  }
}
