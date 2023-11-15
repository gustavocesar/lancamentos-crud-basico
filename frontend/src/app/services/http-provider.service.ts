import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';
import { FiltroLancamento } from '../models/FiltroLancamento';
import CriarLancamentoAvulsoDto from '../models/CriarLancamentoAvulso';
import AlterarLancamentoAvulsoDto from '../models/AlterarLancamentoAvulsoDto';

var apiUrl = 'https://localhost:7104/api';

var httpLink = {
  lancamentos: `${apiUrl}/lancamentos`,
};

@Injectable({
  providedIn: 'root',
})
export class HttpProviderService {
  constructor(private webApiService: WebApiService) {}

  public getAll(filtro: FiltroLancamento): Observable<any> {
    var queryString = `dataInicial=${filtro.dataInicial}&dataFinal=${filtro.dataFinal}`;
    return this.webApiService.get(`${httpLink.lancamentos}?${queryString}`);
  }

  public getById(id: string): Observable<any> {
    return this.webApiService.get(`${httpLink.lancamentos}/${id}`);
  }

  public delete(id: string): Observable<any> {
    return this.webApiService.delete(`${httpLink.lancamentos}/${id}`);
  }

  public post(lancamento: CriarLancamentoAvulsoDto): Observable<any> {
    return this.webApiService.post(httpLink.lancamentos, lancamento);
  }

  public put(id: string, lancamento: AlterarLancamentoAvulsoDto): Observable<any> {
    return this.webApiService.put(`${httpLink.lancamentos}/${id}`, lancamento);
  }
}
