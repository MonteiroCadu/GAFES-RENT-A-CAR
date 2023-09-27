export interface RetornoPaginado<T> {
    tamanhoDaPagina: number;
    paginaCorrente : number;
    quantidadeDeRegistrosDaConsulta: number;
    dados: T[];
  }