class Store {
    subscribes = {};

    static getItem(key) {
        return JSON.parse(localStorage.getItem(key));
    }

    static setItem(key, value) {
        localStorage.setItem(key, JSON.stringify(value));
        if (!this.subscribes?.[key]) {
            return;
        }
        this.subscribes?.[key]?.forEach(callback => callback(value));
    }

    static removeItem(key) {
        localStorage.removeItem(key);
    }

    static subscribe(key, callback) {
        if (!this.subscribes[key]) {
            this.subscribes[key] = [];
        }

        this.subscribes[key].push(callback);
    }

    static unsubscribe(key, callback) {
        if (this.subscribes[key]) {
            this.subscribes[key] = this.subscribes[key].filter(_callback => _callback !== callback);
        }
    }
}

