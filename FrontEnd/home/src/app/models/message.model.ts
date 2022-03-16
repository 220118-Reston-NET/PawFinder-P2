export interface Message
{
    messageID:number;
    senderID:number;
    receiverID:number;
    messageText:string;
    messageTimeStamp: Date;
}