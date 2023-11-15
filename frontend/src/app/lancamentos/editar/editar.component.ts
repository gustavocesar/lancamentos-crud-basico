import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { createMask } from '@ngneat/input-mask';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import AlterarLancamentoAvulsoDto from 'src/app/models/AlterarLancamentoAvulsoDto';
import { HttpProviderService } from 'src/app/services/http-provider.service';

@Component({
  selector: 'app-lancamento-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.scss'],
})
export class EditarComponent implements OnInit {
  constructor(
    private httpProvider: HttpProviderService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  currencyInputMask = createMask({
    alias: 'numeric',
    groupSeparator: '.',
    radixPoint: ',',
    digits: 2,
    digitsOptional: false,
    prefix: 'R$ ',
    placeholder: '0,00',
    allowMinus: true,
    clearIncomplete: true,
  });

  lancamento: AlterarLancamentoAvulsoDto = new AlterarLancamentoAvulsoDto(
    0,
    new Date()
  );

  id: string = '';

  formLancamento: FormGroup = this.formBuilder.group({
    valor: [this.lancamento.valor],
    data: [this.lancamento.data],
  });

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id')!;
    this.carregarLancamento(this.id);
  }

  carregarLancamento(id: string) {
    this.httpProvider.getById(id).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          const lancamento = resultData.data;
          const data = moment(lancamento.data).format('YYYY-MM-DD');
          this.formLancamento.patchValue({
            valor: lancamento.valor,
            data: data,
          });
        }
      }
    });
  }

  cancelar() {
    this.router.navigate(['/Lancamentos']);
  }

  gravar() {
    let { data, valor } = this.formLancamento.value;
    valor = parseFloat(
      valor.toString().replace('R$ ', '').replace('.', '').replace(',', '.')
    );

    const lancamento = new AlterarLancamentoAvulsoDto(valor, data);
    this.httpProvider.put(this.id, lancamento).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.toastr.success('Lançamento incluído com sucesso!');
          this.router.navigate(['/Lancamentos']);
        }
      }
    });
  }
}
