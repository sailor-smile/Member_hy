/**
 * date:2012-11-2 
 * author:douzaixing
 * 可以像java中的hashmap一样使用,具体操作方法如下:
 * 1.首先引用
 * <script type="text/javascript" src="${contextPath}/js/biz/hashMap.js?v=${v}"></script>
   2.var map = new Map();
    map.put("name", "jack");
    map.put("age", "28");
    map.put("gender", "male");
    
    window.console.log(map.get("name"));    
    
    window.console.log(map.isEmpty());
    
    window.console.log(map.get("name"));
    
    window.console.log(map.size());
    
    window.console.log(map.keySet());
    
    window.console.log(map.values());
    
    window.console.log(map.count);
    
    window.console.log(map);
    
    window.console.log("-----------------------------------------");
    
    var map2 = new Map();
    map2.putAll(map);
    
    window.console.log(map2);
    
    map2.remove("gender");
    
    window.console.log(map2);
    window.console.log(map2.size());
    
    window.console.log(map2.containsKey("name"));
    window.console.log(map2.containsValue("jack"));
    
    map2.clear();
    
    window.console.log(map2);
    window.console.log(map2.size());
    
    window.console.log(map2.containsKey("name"));
    window.console.log(map2.containsValue("jack"));
    
    注意：window.console在IE下面不能使用
 */

(function(win) {
    var Map = function() {
        this.count = 0;
        this.entrySet = {};
    };

    var proto = Map.prototype;

    proto.size = function() {
        return this.count;
    };

    proto.isEmpty = function() {
        return this.count === 0;
    };

    proto.containsKey = function(key) {
        if (this.isEmpty()) {
            return false;
        }

        for (var prop in this.entrySet) {
            if (prop == key) {
                return true;
            }
        }

        return false;
    };

    proto.containsValue = function(value) {
        if (this.isEmpty()) {
            return false;
        }

        for ( var key in this.entrySet) {
            if (this.entrySet[key] == value) {
                return true;
            }
        }

        return false;
    };

    proto.get = function(key) {
        if (this.isEmpty()) {
            return null;
        }

        if (this.containsKey(key)) {
            return this.entrySet[key];
        }

        return null;
    };

    proto.put = function(key, value) {
    	this.remove(key);
        this.entrySet[key] = value;
        this.count++;
    };

    proto.remove = function(key) {
        if (this.containsKey(key)) {
            delete this.entrySet[key];
            this.count--;
        }
    };

    proto.putAll = function(map) {if(!map instanceof Map){return;}
        for ( var key in map.entrySet) {
            this.put(key, map.entrySet[key]);
        }
    };

    proto.clear = function() {
        for ( var key in this.entrySet) {
            this.remove(key);
        }
    };

    proto.values = function() {
        var result = [];

        for ( var key in this.entrySet) {
            result.push(this.entrySet[key]);
        }

        return result;
    };

    proto.keySet = function() {
        var result = [];

        for ( var key in this.entrySet) {
            result.push(key);
        }

        return result;
    };

    proto.toString = function() {
        var result = [];
        for ( var key in this.entrySet) {
            result.push(key + ":" + this.entrySet[key]);
        }

        return "{" + result.join() + "}";
    };

    proto.valueOf = function() {
        return this.toString();
    };

    win.Map = Map;
})(window);