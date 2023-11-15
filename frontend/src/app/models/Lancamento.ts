export interface Lancamento {
  id: string;
  idCurto: string;
  descricao: string;
  data: Date;
  valor: number;
  avulso: boolean;
  status: boolean;
}
