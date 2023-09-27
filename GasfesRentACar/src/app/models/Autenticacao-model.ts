import { AccessToken } from "./AccessToken-model";

export interface AutenticacaoUsuario{
    dados:AccessToken;
    notifications:[];
    valid:boolean;
}