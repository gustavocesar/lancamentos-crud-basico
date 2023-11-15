import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { createMask } from '@ngneat/input-mask';
import { ToastrService } from 'ngx-toastr';
import CriarLancamentoAvulsoDto from 'src/app/models/CriarLancamentoAvulso';
import { HttpProviderService } from 'src/app/services/http-provider.service';

@Component({
  selector: 'app-lancamento-incluir',
  templateUrl: './incluir.component.html',
  styleUrls: ['./incluir.component.scss'],
})
export class IncluirComponent implements OnInit {
  constructor(
    private httpProvider: HttpProviderService,
    private formBuilder: FormBuilder,
    private router: Router,
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

  lancamento: CriarLancamentoAvulsoDto = new CriarLancamentoAvulsoDto('', 0);

  formLancamento: FormGroup = this.formBuilder.group({
    descricao: [this.lancamento.descricao],
    valor: [this.lancamento.valor],
  });

  ngOnInit() {}

  cancelar() {
    this.router.navigate(['/Lancamentos']);
  }

  gravar() {
    let { descricao, valor } = this.formLancamento.value;
    valor = parseFloat(
      valor.toString().replace('R$ ', '').replace('.', '').replace(',', '.')
    );

    const lancamento = new CriarLancamentoAvulsoDto(descricao, valor);

    this.httpProvider.post(lancamento).subscribe((data: any) => {
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
