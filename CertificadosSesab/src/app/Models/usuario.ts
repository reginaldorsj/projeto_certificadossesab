import {Unidade} from './unidade';

export class Usuario {
	private _id_usuario: number;
	private _id_unidade: Unidade;
	private _nome: string;
	private _login: string;
	private _senha: string;
	private _e_mail: string;

	public get IdUsuario(): number {
		return this._id_usuario;
	}

	public set IdUsuario(idUsuario: number) {
		this._id_usuario = idUsuario;
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

	public get Login(): string {
		return this._login;
	}

	public set Login(login: string) {
		this._login = login;
	}

	public get Senha(): string {
		return this._senha;
	}

	public set Senha(senha: string) {
		this._senha = senha;
	}

	public get EMail(): string {
		return this._e_mail;
	}

	public set EMail(eMail: string) {
		this._e_mail = eMail;
	}

}
