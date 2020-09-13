import { Unidade } from './unidade';

export class Evento {
	private _id_evento: number;
	private _id_unidade: Unidade;
  private _nome: string;
  private _arquivo_certificado: string;
	private _x: number;
	private _y: number;
	private _data_liberacao_documento: Date;

	public get IdEvento(): number {
		return this._id_evento;
	}

	public set IdEvento(idEvento: number) {
		this._id_evento = idEvento;
	}

	public get Unidade(): Unidade {
		return this._id_unidade;
	}

	public set Unidade(unidade : Unidade) {
		this._id_unidade = unidade;
	}

	public get Nome(): string {
		return this._nome;
	}

	public set Nome(nome: string) {
		this._nome = nome;
	}

  public get ArquivoCertificado(): string {
		return this._arquivo_certificado;
	}

  public set ArquivoCertificado(arquivoCertificado: string) {
		this._arquivo_certificado = arquivoCertificado;
	}

	public get X(): number {
		return this._x;
	}

	public set X(x: number) {
		this._x = x;
	}

	public get Y(): number {
		return this._y;
	}

	public set Y(y: number) {
		this._y = y;
	}

	public get DataLiberacaoDocumento(): Date {
		if (this._data_liberacao_documento && !(this._data_liberacao_documento instanceof Date)) {
			this._data_liberacao_documento = new Date(this._data_liberacao_documento);
		}
		return this._data_liberacao_documento; 
	}

	public set DataLiberacaoDocumento(dataLiberacaoDocumento: Date) {
		this._data_liberacao_documento = dataLiberacaoDocumento;
	}

}
