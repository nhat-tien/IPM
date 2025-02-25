
export class AppLog {

  public static error(message: string) {
    console.log(`>>> IPM [ERROR]: ` + message);
  }

  public static cache(message: string) {
    console.log(`>>> IPM [CACHE]: ` + message);
  }
}
