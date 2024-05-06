import { giftList } from "./giftList.model";

export class User {
    public Id: number | undefined;
    public userName: string | undefined;
    public email: string | undefined;
    public firstName: string | undefined;
    public lastName: string | undefined;
    public password: string | undefined;
    public phonNumber: string | undefined;
    public role: number | undefined;
    public orders!: giftList[];
}