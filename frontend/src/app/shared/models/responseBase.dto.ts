import { HttpStatusCode } from "@angular/common/http";

export interface ResponseBase {
    StatusCode: HttpStatusCode;
    Mensagem: string;
    Data: any;
}