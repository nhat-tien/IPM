type Cache = {
  time: number, 
  timeExpired: number // second
  data: any
}

let cache = $state(new Map<string, Cache>());

function isValid(time: number | undefined, timeExpired: number | undefined): boolean {
  if(!time || !timeExpired) {
    return false;
  }
  const milisec = Date.now() - time;
  return timeExpired > Math.floor(milisec/1000);
}

export async function cacheFetch<T>(key: string, timeExpired: number, fetchCallback: () => Promise<T>): Promise<T> {
  if(!cache.has(key) || !isValid(cache.get(key)?.time, cache.get(key)?.timeExpired)) {

    const data: T = await fetchCallback();

    cache.set(key, {
      time: Date.now(),
      timeExpired: timeExpired,
      data: data
    });

    return new Promise((resolve, _) => {
      resolve(data);
    })
  }

  const data = cache.get(key)?.data!;

  return new Promise((resolve, _) => {
    resolve(data);
  });
}
